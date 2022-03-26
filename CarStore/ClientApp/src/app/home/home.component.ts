import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  cars: CarItem[];
  carForm = new FormGroup({
    carName: new FormControl('', [
      Validators.required
    ]),
    carModel: new FormControl('', [
      Validators.required
    ]),
    carYear: new FormControl('', [
      Validators.required,
      Validators.pattern("^[0-9]*$")
    ])
  })


  get carName() { return this.carForm.get('carName'); }
  get carModel() { return this.carForm.get('carModel'); }
  get carYear() { return this.carForm.get('carYear'); }

  addCar() {
    if (this.carForm.valid) {
      let _self = this;
      
      let bodyContent = {
        'name': this.carForm.value.carName,
        'model': this.carForm.value.carModel,
        'year': parseInt(this.carForm.value.carYear)
      };

      this.http.post(this.baseUrl + 'Car', bodyContent)
        .subscribe(
          () => {
            _self.getAllCars();
          },
          error => {
            console.log('post error', error);
          });
    }
  }
  setCarForm(car: any): void {
    this.carForm.reset({
      'carName': car.name,
      'carModel': car.model,
      'carYear': car.year
    });
  }

  getAllCars() {
    this.http.get<CarItem[]>(this.baseUrl + 'Car')
      .subscribe(
        result => {
          this.cars = result;
        },
        error => {
          console.log(error)
        });
  }

  ngOnInit() {
    this.getAllCars();
  }
}

interface CarItem {
  name: string;
  model: string;
  year: number;
}
