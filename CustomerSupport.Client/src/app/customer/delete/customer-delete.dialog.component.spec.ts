import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';
import { CustomerService } from 'src/app/services/customer.service';

import { CustomerDeleteDialogComponent } from './customer-delete.dialog.component';

describe('CustomerDeleteDialogComponent', () => {
  let component: CustomerDeleteDialogComponent;
  let fixture: ComponentFixture<CustomerDeleteDialogComponent>;

  let toasterServiceSpy: jasmine.Spy;
  const toasterSetvices = jasmine.createSpyObj('toasterSetvices', ['pop']);
     toasterServiceSpy = toasterSetvices.pop.and.returnValue(of(''));

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerDeleteDialogComponent ],
      providers:[
        { provide: CustomerService, useClass: MockService },
        { provide: MAT_DIALOG_DATA, useValue: {} },
        { provide: MatDialogRef, useValue: {} },
        { provide: ToastrService, useValue: toasterSetvices }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerDeleteDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

class MockService {
}
