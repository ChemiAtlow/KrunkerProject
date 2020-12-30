import { guid } from "./Guid";
import { ItemKind } from "./ItemKind";

export interface ShoppingItem {
	name: string;
	uriImg: string;
	discount: number;
	price: number;
	id: guid;
	currentAmount: number;
	kind: ItemKind;
}
