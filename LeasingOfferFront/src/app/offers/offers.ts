import { Component, inject, OnInit, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OfferService, Offer } from '../offer.service';

@Component({
  selector: 'app-offers',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './offers.html',
  styleUrl: './offers.css'
})
export class OffersComponent implements OnInit {
  private offerService = inject(OfferService);

  offers = computed(() => this.offerService.offers());

  ngOnInit() {
    this.offerService.getAll();
  }
}
