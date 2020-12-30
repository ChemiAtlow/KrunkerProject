import { ItemKind } from "./ItemKind";
import { PriceFilter } from "./PriceFilter";

export interface Filters {
	stock: boolean;
	discount: boolean;
	type: keyof typeof ItemKind | "All";
	price: keyof typeof PriceFilter;
}
