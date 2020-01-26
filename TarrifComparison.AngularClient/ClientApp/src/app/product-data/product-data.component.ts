import { Component, Inject, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment} from '../../environments/environment';

@Component({
  selector: 'app-product-data',
  templateUrl: './product-data.component.html'
})
export class ProductDataComponent {
  public tarrifs: tarrif[];
  public disabledLoader = true;
  public consumedUnits: number;

  constructor(private http: HttpClient) {

  }

  onKey(event: { target: { value: number; }; }) { this.consumedUnits = event.target.value; }

public GetTarrifsByConsumption() {
  this.disabledLoader = false;
  this.http.get<tarrif[]>(environment.ProductCompareAPIBaseUrl + '/tarrif/' + this.consumedUnits).subscribe(result => {
      this.tarrifs = result;
    }, error => console.error(error));
  }

}



// tslint:disable-next-line: class-name
interface tarrif {
  name: string;
  annualCost: number;
}
