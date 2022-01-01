import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {SearchResults} from "../../../modules/search-results/models/search-results";
import {ApiPaths, environment} from "../../../../environments/environment";

@Injectable()
export class SearchService {

  constructor(private httpClient: HttpClient) { }


  public getSearchResults(query: string, count: number, page: number) : Observable<SearchResults> {
    return this.httpClient
      .get<SearchResults>(environment.baseUrl + ApiPaths.searchResultsGet + `?query=${query}&count=${count}&page=${page}`);
  }
}
