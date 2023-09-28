import { TestBed } from '@angular/core/testing';

import { GithubRepositoriesService } from './github-repositories.service';

describe('GithubRepositoriesService', () => {
  let service: GithubRepositoriesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GithubRepositoriesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
