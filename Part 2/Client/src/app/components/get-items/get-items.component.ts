import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from 'src/app/models/Item';
import { GithubRepositoriesService } from 'src/app/services/github-repositories.service';

@Component({
  selector: 'app-get-items',
  templateUrl: './get-items.component.html',
  styleUrls: ['./get-items.component.css']
})
export class GetItemsComponent implements OnInit {

  bookmarkedItems: Array<Item> = [];

  constructor(private githubRepositoriesService: GithubRepositoriesService
    , private router: Router) { }

  ngOnInit(): void {
    this.getBookmarkedItems();
  }


  getBookmarkedItems() {
    this.githubRepositoriesService.getBookmarkedItems().subscribe(
      (items: Item[]) => {
        this.bookmarkedItems = items;
      },
      error => {
        console.error('Error fetching bookmarked items:', error);
      }
    );
  }

  removeItem(itemId: number) {
    this.githubRepositoriesService.removeBookmarkItem(itemId).subscribe(
      () => {
        if (this.bookmarkedItems.length === 1) {
          this.refreshPage();
        } else {
          this.getBookmarkedItems();
        }
      },
      error => {
        console.error('Error removing item:', error);
      }
    );
  }

  refreshPage() {
    window.location.reload();
  }

  navigateToSearchItemsPage() {
    this.router.navigate(['/search-items']);
  }

}
