import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/customer.model';
import { Inquiry } from '../models/inquiry.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private readonly API_URL = environment.apiUrl + '/customer';

  dataChange: BehaviorSubject<Customer[]> = new BehaviorSubject<Customer[]>([]);
  dataChangeInquiry: BehaviorSubject<Inquiry[]> = new BehaviorSubject<Inquiry[]>([]);
  
  dialogData: any;

  constructor (private httpClient: HttpClient) {}

  get data(): Customer[] {
    return this.dataChange.value;
  }

  getById(id: string) : Observable<Customer>{
    let url = `${this.API_URL}/get/${id}`;
    return this.httpClient.get<Customer>(url);
  }

  getDialogData() {
    return this.dialogData;
  }

  getAll(): Observable<Customer[]> {
    let url = this.API_URL + '/getall';

    this.httpClient.get<Customer[]>(url).subscribe(data => {      
      this.dataChange.next(data);
      },
      (error) => {
      console.log (error.name + ' ' + error.message);
      });

    return this.dataChange;
  }

  getInquiries(): Observable<Inquiry[]> {
    let url = this.API_URL + '/inquiries';

    this.httpClient.get<Inquiry[]>(url).subscribe(data => {      
      this.dataChangeInquiry.next(data);
      },
      (error) => {
      console.log (error.name + ' ' + error.message);
      });

    return this.dataChangeInquiry;
  }

  add<T> (data: Customer): Observable<T> {
    let url = `${this.API_URL}/add`;
    var teste = {email: data.email, phone: data.phone, issueDescription: data.issueDescription}
    return this.httpClient.post<T>(url, teste);
  }


  update<T> (data: Customer): Observable<T> {
    let url = `${this.API_URL}/update`;
    return this.httpClient.put<T>(url, data);
  }

  delete<T> (id: string): Observable<T> {
    let url = `${this.API_URL}/${id}`;
    return this.httpClient.delete<T>(url);
  }
}
