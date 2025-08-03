import { Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout/layout';
import { OffersComponent } from './offers/offers';
import { SuppliersComponent } from './suppliers/suppliers';
import { SearchComponent } from './search/search';

export const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        redirectTo: 'offers',
        pathMatch: 'full'
      },
      {
        path: 'offers',
        component: OffersComponent,
      },
      {
        path: 'suppliers',
        component: SuppliersComponent,
      },
      {
        path: 'search',
        component: SearchComponent,
      },
    ]
  }
];
