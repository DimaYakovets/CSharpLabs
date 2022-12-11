import axios from "axios";

import { IModel } from "../models";

export default class Repository<T extends IModel> {
    apiurl: string;

    constructor(apiurl: string) {
        this.apiurl = apiurl;
    }

    async getAll(): Promise<T[]> {
        const res = await axios.get(this.apiurl);
        
        return res.status === 200 ? res.data : [];
    }

    async create(model: T): Promise<T> {
        const res = await axios.post(this.apiurl, model);
        
        return res.status === 200 ? res.data : {};
    }

    async update(id: number, model: T): Promise<T> {
        const res = await axios.put(this.apiurl + '/' + id, model);
        
        return res.status === 200 ? res.data : {};
    }

    async delete(id: number): Promise<boolean> {
        const res = await axios.delete(this.apiurl + '/' + id);
        
        return res.status === 200;
    }
}