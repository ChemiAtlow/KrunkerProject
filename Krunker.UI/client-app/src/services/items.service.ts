import {
	Filters,
	Guid,
	guid,
	ItemKind,
	ShoppingItem,
	ShoppingItemForm,
} from "@/models";
import { apiConstants } from "@/constants";
import axios, { AxiosRequestConfig } from "axios";
import { reactive } from "vue";
import { messagesService } from "./messages.service";

const { API_URL, SHOPPING_ITEMS_ENDPOINT } = apiConstants;

const isValidNoneEmptyGuid = (guid: guid) =>
	Guid.isValid(guid) && !Guid.isEmpty(guid);

const state = reactive<{
	filters: Filters;
	items: ShoppingItem[];
	nonFilteredItems: ShoppingItem[];
}>({
	filters: { discount: false, stock: false, type: "All", price: "AllItems" },
	items: [],
	nonFilteredItems: [],
});

const filterItems = () => {
	state.items = state.nonFilteredItems.filter(i => {
		const discountFilter = !state.filters.discount || i.discount;
		const stockFilter = !state.filters.stock || i.currentAmount;
		const typeFilter =
			state.filters.type === "All" ||
			i.kind === ItemKind[state.filters.type];
		const calculatedPrice = i.price - (i.price * i.discount) / 100;
		const priceFilter =
			state.filters.price === "AllItems" ||
			(state.filters.price === "UpTo150" && calculatedPrice <= 150) ||
			(state.filters.price === "UpTo500" && calculatedPrice <= 500) ||
			(state.filters.price === "UpTo1000" && calculatedPrice <= 1000) ||
			(state.filters.price === "UpTo1500" && calculatedPrice <= 1500);
		return discountFilter && stockFilter && typeFilter && priceFilter;
	});
};

const resetFilters = () => {
	state.filters = {
		discount: false,
		price: "AllItems",
		stock: false,
		type: "All",
	};
	filterItems();
};

const getAll = async () => {
	try {
		const items = await axios.get<ShoppingItem[]>(
			`${API_URL}/${SHOPPING_ITEMS_ENDPOINT}`
		);
		state.nonFilteredItems = items.data;
		filterItems();
	} catch (e) {
		messagesService.showToast("Can't load files from server!");
	}
};

const getById: (id: guid) => Promise<ShoppingItemForm> = async id => {
	if (!state.items.length) {
		await getAll();
	}
	const item = state.items.find(i => i.id === id);
	if (!item) throw new Error("Key not found!");
	return item;
};

const useOrReturnItem = (
	itemId: guid,
	type: "use" | "return",
	amount: number
) => {
	if (isValidNoneEmptyGuid(itemId)) {
		const item = state.items.find(i => i.id === itemId);
		if (item && type == "use") {
			item.currentAmount -= amount;
		} else if (item && type == "return") {
			item.currentAmount += amount;
		}
	}
};

const editOrCreateItem = async (item: ShoppingItemForm) => {
	const form = new FormData();
	for (const [key, value] of Object.entries(item)) {
		form.append(key, value);
	}
	const axiosRequest: AxiosRequestConfig = {
		data: form,
	};
	if (isValidNoneEmptyGuid(item.id)) {
		axiosRequest.url = `${API_URL}/${SHOPPING_ITEMS_ENDPOINT}/${item.id}`;
		axiosRequest.method = "PUT";
	} else {
		axiosRequest.url = `${API_URL}/${SHOPPING_ITEMS_ENDPOINT}`;
		axiosRequest.method = "POST";
	}
	const returned = await axios.request<ShoppingItem>(axiosRequest);
	const indexInState = state.items.findIndex(
		it => it.id === returned.data.id
	);
	if (indexInState < 0) {
		state.items.push(returned.data);
	} else {
		state.items[indexInState] = returned.data;
	}
	messagesService.showToast("Item saved successfully.");
};

const deleteItem = async (itemId: guid) => {
	if (isValidNoneEmptyGuid(itemId)) {
		try {
			await axios.delete(
				`${API_URL}/${SHOPPING_ITEMS_ENDPOINT}/${itemId}`
			);
			state.items = state.items.filter(i => i.id !== itemId);
		} catch (e) {
			messagesService.showToast("Couldn't delete the item.");
		}
	}
};

export const itemsService = {
	state,
	resetFilters,
	filterItems,
	getAll,
	getById,
	useOrReturnItem,
	editOrCreateItem,
	deleteItem,
};
