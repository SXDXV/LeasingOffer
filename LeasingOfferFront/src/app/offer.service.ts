import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export type Offer = {
  id: number;
  brand: string;
  model: string;
  supplierId: number;
  supplierName: string;
  registeredAt: string;
};

@Injectable({
  providedIn: 'root',
})
export class OfferService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'https://localhost:7064/api/Offers/search';

  readonly offers = signal<Offer[]>([]);
  readonly loading = signal(false);

  getAll() {
    this.loading.set(true);
    this.http.get<{ items: Offer[] }>(this.apiUrl).subscribe({
      next: (res) => {
        this.offers.set(res.items);
        this.loading.set(false);
      },
      error: (err) => {
        console.error('Ошибка при получении офферов:', err);
        this.loading.set(false);
      }
    });
  }

  search(params: { brand?: string; model?: string; supplierName?: string }) {
    this.loading.set(true);
    const queryParams = new URLSearchParams();

    if (params.brand) queryParams.append('brand', params.brand);
    if (params.model) queryParams.append('model', params.model);
    if (params.supplierName) queryParams.append('supplierName', params.supplierName);

    const url = `${this.apiUrl}?${queryParams.toString()}`;

    this.http.get<{ items: Offer[] }>(url).subscribe({
      next: (res) => {
        this.offers.set(res.items);
        this.loading.set(false);
      },
      error: (err) => {
        console.error('Ошибка при поиске офферов:', err);
        this.loading.set(false);
      },
    });
  }
}
