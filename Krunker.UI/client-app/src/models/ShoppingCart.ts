import { guid } from "./Guid";
import { Purchase } from "./Purchase";

export interface ShoppingCart {
	id: guid;
	totalPrice: number;
	purchaseComplete: boolean;
	purchaseTime: string;
	purchases: Purchase[];
}
