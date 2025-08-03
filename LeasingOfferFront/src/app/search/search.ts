import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OfferService } from '../offer.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search.html',
  styleUrl: './search.css',
})
export class SearchComponent implements OnInit {
  private offerService = inject(OfferService);

  brand = '';
  model = '';
  supplierName = '';
  offers = this.offerService.offers;
  loading = this.offerService.loading;

  ngOnInit() {
    this.offerService.getAll();
  }

  search() {
    this.offerService.search({
      brand: this.brand.trim(),
      model: this.model.trim(),
      supplierName: this.supplierName.trim()
    });
  }

  reset() {
    this.brand = '';
    this.model = '';
    this.supplierName = '';
    this.search();
  }
}
