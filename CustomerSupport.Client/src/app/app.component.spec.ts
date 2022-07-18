import { Component } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  let toasterServiceSpy: jasmine.Spy;
  const toasterSetvices = jasmine.createSpyObj('toasterSetvices', ['pop']);
     toasterServiceSpy = toasterSetvices.pop.and.returnValue(of(''));

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        AppComponent,
        CustomerComponent
      ],
      providers:[
        { provide: ToastrService, useValue: toasterSetvices }
      ]
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'CustomerSupport.Client'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('CustomerSupport.Client');
  });
});

@Component({ selector: 'app-customer', template: '' })
class CustomerComponent {
}
