import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-tabs',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './tabs.html',
  styleUrl: './tabs.css'
})
export class TabsComponent {
  tabs = [
    { label: 'Популярные поставщики', route: '/suppliers' },
    { label: 'Поиск', route: '/search' },
    { label: 'Все офферы', route: '/offers' },
  ];
}
