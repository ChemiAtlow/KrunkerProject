import { Purchase, ShoppingCart, ShoppingItem } from "@/models";
import { apiConstants } from "@/constants";
import axios from "axios";
import { reactive } from "vue";
import { messagesService } from "./messages.service";
import { itemsService } from "./items.service";

const { API_URL, CART_ENDPOINT, PURCHASE_ENDPOINT } = apiConstants;

const state = reactive<{ cart: ShoppingCart | null; reports: ShoppingCart[] }>({
	cart: null,
	reports: [],
});

const getAllPurchases = async () => {
	try {
		const cart = await axios.get<ShoppingCart[]>(
			`${API_URL}/${PURCHASE_ENDPOINT}`
		);
		state.reports = cart.data;
	} catch (e) {
		messagesService.showToast("Couldn't get purchase reports!");
	}
};

const getPurchaseTotalPrice = (purchase: Purchase) => {
	if (!purchase) return 0;
	const price =
		purchase.priceAtPurchase -
		(purchase.priceAtPurchase * purchase.discountRate) / 100;
	return price * purchase.amount;
};

const getNewCart = async () => {
	try {
		const cart = await axios.get<ShoppingCart>(
			`${API_URL}/${CART_ENDPOINT}`
		);
		state.cart = cart.data;
	} catch (e) {
		messagesService.showToast("Couldn't create shopping cart!");
	}
};

const addItemToCart = async (item: ShoppingItem, amount: number) => {
	try {
		if (!state.cart) await getNewCart();
		const purchaseData = await axios.put<Purchase>(
			`${API_URL}/${CART_ENDPOINT}/${state.cart?.id}`,
			{
				itemId: item.id,
				amount,
			}
		);
		const { data: purchase } = purchaseData;
		itemsService.useOrReturnItem(item.id, "use", amount);
		if (state.cart) {
			const purchaseIndex = state.cart.purchases.findIndex(
				p => p.id === purchase.id
			);
			if (purchaseIndex < 0) {
				state.cart.purchases.push(purchase);
				state.cart.totalPrice += getPurchaseTotalPrice(purchase);
			} else {
				const previousPrice = getPurchaseTotalPrice(
					state.cart.purchases[purchaseIndex]
				);
				state.cart.purchases[purchaseIndex] = purchase;
				state.cart.totalPrice +=
					getPurchaseTotalPrice(purchase) - previousPrice;
			}
		}
		messagesService.showToast("Added item to cart!");
	} catch (e) {
		messagesService.showToast("Failed adding item to cart!");
	}
};

const removePurchaseFromCart = async (purchase: Purchase) => {
	try {
		if (!state.cart) await getNewCart();
		const deleted = await axios.delete<Purchase>(
			`${API_URL}/${CART_ENDPOINT}/${state.cart?.id}/${purchase.id}`
		);
		itemsService.useOrReturnItem(
			purchase.item.id,
			"return",
			deleted.data.amount
		);
		if (state.cart) {
			state.cart.purchases = state.cart.purchases.filter(
				p => p.id !== purchase.id
			);
			state.cart.totalPrice -= getPurchaseTotalPrice(purchase);
		}
		messagesService.showToast("Removed from cart!");
	} catch (e) {
		messagesService.showToast("Failed removing from cart!");
	}
};

const purchaseCart = async () => {
	if (!state.cart) return;
	try {
		await axios.post<void>(
			`${API_URL}/${PURCHASE_ENDPOINT}/${state.cart.id}`
		);
		state.cart = null;
		getNewCart();
		messagesService.showToast("Purchase completed!");
	} catch (e) {
		messagesService.showToast("Purchase failed!");
	}
};

export const cartService = {
	state,
	getAllPurchases,
	getNewCart,
	addItemToCart,
	removePurchaseFromCart,
	purchaseCart,
};
