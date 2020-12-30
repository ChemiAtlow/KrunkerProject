import { guid } from "./Guid";
import { ShoppingItem } from "./ShoppingItem";

export interface Purchase {
	id: guid;
	item: ShoppingItem;
	amount: number;
	discountRate: number;
	priceAtPurchase: number;
}
