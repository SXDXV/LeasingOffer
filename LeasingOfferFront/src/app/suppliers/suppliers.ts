import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SupplierService } from '../supplier.service';

@Component({
  selector: 'app-suppliers',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './suppliers.html',
  styleUrl: './suppliers.css'
})
export class SuppliersComponent implements OnInit {
  private supplierService = inject(SupplierService);

  topSuppliers = this.supplierService.topSuppliers;

  ngOnInit() {
    this.supplierService.getTopSuppliers();
  }
}
