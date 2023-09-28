import { Owner } from "./Owner";

export class Item {
    id: number = -1;
    name: string = '';
    owner!: Owner;
}