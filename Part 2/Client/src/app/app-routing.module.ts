import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchItemsComponent } from './components/search-items/search-items.component';
import { GetItemsComponent } from './components/get-items/get-items.component';

const routes: Routes = [
  { path: '', redirectTo: 'search-items', pathMatch: 'full' },
  { path: 'search-items', component: SearchItemsComponent },
  { path: 'get-items', component: GetItemsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
