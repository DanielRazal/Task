import { Component, OnInit } from '@angular/core';
import { Rootobject } from './models/Rootobject';
import { Item } from './models/Item';
import { AlertService } from './services/alert.service';
import { GithubRepositoriesService } from './services/github-repositories.service';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Part-2-API';
  searchKeyword = '';
  searchResults: Rootobject | null = null;
  errorMessage = '';
  bookmarkedItems: Array<Item> = [];
  constructor(private githubRepositoriesService: GithubRepositoriesService,
    private alertService: AlertService, private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.getBookmarkedItems();
  }

  performSearch() {
    this.searchResults = null;

    if (this.searchKeyword) {
      this.githubRepositoriesService.searchAsync(this.searchKeyword)
        .subscribe(
          (result) => {
            this.searchResults = result;
          },
          (error) => {
            this.errorMessage = error.error;
          }
        );
    }
  }

  sendDetailsToEmail(item: Item) {
    this.alertService.showEmailInput().then((result) => {
      if (result.isConfirmed && result.value) {
        const email = result.value;
        this.githubRepositoriesService.sendEmail(email, item).subscribe(
          (response) => {
            this.alertService.success('Success', response.message, `Status code: ${response.statusCode}`);
          },
          (error) => {
            console.error("Error");
            console.error(error);
          },
          () => {
            console.log("Observable completed");
          }
        );
      }
    });
  }


  setBookmarkItem(item: Item) {
    this.githubRepositoriesService.setBookmarkItem(item).subscribe(
      (response) => {
        this.alertService.success('Success', response.message, `Status code: ${response.statusCode}`);
        console.log(item);
        // var x = this.getBookmarkedItems();
        // console.log(x);
      },
      (error) => {
        console.error("Error");
        console.error(error);
      },
      () => {
        console.log("Observable completed");
      }
    );
  }

  // getBookmarkedItems() {
  //   this.githubRepositoriesService.getBookmarkedItems().subscribe(
  //     (data) => {
  //       console.log("Bookmarked Items:", data);
  //     },
  //     (error) => {
  //       console.error("Error");
  //       console.error(error);
  //     },
  //     () => {
  //       console.log("Observable completed");
  //     }
  //   );
  // }

  // Example usage in your component
  bookmarkItem(item: Item) {
    this.githubRepositoriesService.setBookmarkItem(item).subscribe(response => {
      // After bookmarking, you should have items in the session
      // this.getBookmarkedItems();
    });
  }

  getBookmarkedItems() {
    this.githubRepositoriesService.getBookmarkedItems().subscribe(
      items => {
        console.log('Received bookmarked items:', items);
        this.bookmarkedItems = items;
        console.log(this.bookmarkedItems);
      },
      error => {
        console.error('Error fetching bookmarked items:', error);
      }
    );
  }


}
