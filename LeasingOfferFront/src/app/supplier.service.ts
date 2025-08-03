import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export type TopSupplier = {
  id: number;
  name: string;
  offerCount: number;
};

@Injectable({
  providedIn: 'root',
})
export class SupplierService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'https://localhost:7064/api/Suppliers/top';

  readonly topSuppliers = signal<TopSupplier[]>([]);

  getTopSuppliers() {
    this.http.get<TopSupplier[]>(this.apiUrl).subscribe({
      next: (res) => this.topSuppliers.set(res),
      error: (err) => console.error('Ошибка при получении поставщиков:', err),
    });
  }
}
