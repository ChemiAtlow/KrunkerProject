import { guid } from "./Guid";
import { ItemKind } from "./ItemKind";
import { KnifeType } from "./KnifeType";

export interface ShoppingItemForm {
	id: guid;
	kind: ItemKind;
	name: string;
	discount: number;
	price: number;
	currentAmount: number;
	image?: File;
	//BackItem
	isWings?: boolean;
	//Weapon
	creator?: string;
	year?: number;
	firePower?: number;
	automatic?: boolean;
	//PrimaryWeapon
	amountBalls?: number;
	shootingRange?: number;
	//SecondaryWeapon
	knifeLength?: number;
	typeKnife?: KnifeType;
}
