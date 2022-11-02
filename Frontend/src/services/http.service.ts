import { Injectable } from '@angular/core';
import axios from 'axios';

export const customAxios = axios.create({
  baseURL: 'http://localhost:5177'
});

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  async getBoxes()
  {
    const httpResponse = await customAxios.get<any>('box');
    return httpResponse.data;
  }
}
