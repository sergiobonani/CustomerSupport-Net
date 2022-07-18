import { TestBed } from '@angular/core/testing';
import { ToastrService } from 'ngx-toastr';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { AlertService } from './alert.service';
import { of } from 'rxjs';

describe('AlertService', () => {
  let service: AlertService;

  let toasterServiceSpy: jasmine.Spy;
  const toasterSetvices = jasmine.createSpyObj('toasterSetvices', ['pop']);
     toasterServiceSpy = toasterSetvices.pop.and.returnValue(of(''));

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        { provide: ToastrService, useValue: toasterSetvices }
      ]
    });
    service = TestBed.inject(AlertService);
  });

  it('should be created', () => {    
    expect(service).toBeTruthy();
  });
});
