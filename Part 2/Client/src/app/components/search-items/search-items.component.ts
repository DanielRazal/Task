import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from 'src/app/models/Item';
import { Rootobject } from 'src/app/models/Rootobject';
import { AlertService } from 'src/app/services/alert.service';
import { GithubRepositoriesService } from 'src/app/services/github-repositories.service';

@Component({
  selector: 'app-search-items',
  templateUrl: './search-items.component.html',
  styleUrls: ['./search-items.component.css']
})
export class SearchItemsComponent {
  searchKeyword = '';
  searchResults: Rootobject | null = null;
  errorMessage = '';

  constructor(private githubRepositoriesService: GithubRepositoriesService,
    private alertService: AlertService, private router: Router) { }

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
          }
        );
      }
    });
  }

  setBookmarkItem(item: Item) {
    this.githubRepositoriesService.setBookmarkItem(item).subscribe(
      (response) => {
        this.alertService.success('Success', response.message, `Status code: ${response.statusCode}`);
      },
      (error) => {
        console.error("Error");
        console.error(error);
      }
    );
  }

  navigateToGetItemsPage() {
    this.router.navigate(['/get-items']);
  }
}