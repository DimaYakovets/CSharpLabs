export interface IModel {
    id: number
}

export class Address implements IModel {
    id: number;
    city: string;
    street: string;
    houseNumber: number;
    flatNumber: number;

    constructor(
        id: number,
        city: string,
        street: string,
        houseNumber: number,
        flatNumber: number
    ) {
        this.id = id
        this.city = city
        this.street = street
        this.houseNumber = houseNumber
        this.flatNumber = flatNumber
    }
}

export class Client {
    id: number;
    firstname: string;
    surname: string;
    patronymic: string;
    phone: string;

    constructor(
        id: number,
        firstname: string,
        surname: string,
        patronymic: string,
        phone: string,
        addressId: number
    ) {
        this.id = id
        this.firstname = firstname
        this.surname = surname
        this.patronymic = patronymic
        this.phone = phone
        this.addressId = addressId
    } addressId: number;
}

export class Order {
    id: number;
    date: string;
    clientId: number;

    constructor(id: number, date: string, clientId: number) {
        this.id = id
        this.date = date
        this.clientId = clientId
    }
}

export class OrderPart {
    id: number;
    orderId: number;
    pizzaId: number;
    discount: number;
    count: number;

    constructor(
        id: number,
        orderId: number,
        pizzaId: number,
        discount: number,
        count: number
    ) {
        this.id = id
        this.orderId = orderId
        this.pizzaId = pizzaId
        this.discount = discount
        this.count = count
    }
}

export class Pizza {
    id: number;
    price: number;
    description: string;

    constructor(id: number, price: number, description: string) {
        this.id = id
        this.price = price
        this.description = description
    }
}