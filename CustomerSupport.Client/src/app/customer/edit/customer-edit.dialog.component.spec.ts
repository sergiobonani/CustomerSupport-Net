import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Observable, of } from 'rxjs';
import { Inquiry } from 'src/app/models/inquiry.model';
import { CustomerService } from 'src/app/services/customer.service';

import { CustomerEditDialogComponent } from './customer-edit.dialog.component';

describe('CustomerEditDialogComponent', () => {
  let component: CustomerEditDialogComponent;
  let fixture: ComponentFixture<CustomerEditDialogComponent>;
  
  let toasterServiceSpy: jasmine.Spy;
  const toasterSetvices = jasmine.createSpyObj('toasterSetvices', ['pop']);
     toasterServiceSpy = toasterSetvices.pop.and.returnValue(of(''));

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerEditDialogComponent ],
      imports: [
        FormsModule,
        ReactiveFormsModule
      ],
      providers:[
        { provide: CustomerService, useClass: MockService },
        { provide: MAT_DIALOG_DATA, useValue: {} },
        { provide: MatDialogRef, useValue: {} },
        { provide: ToastrService, useValue: toasterSetvices }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerEditDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

class MockService {
  getInquiries(): Observable<Inquiry[]> {
    return of([]);
  } 
}