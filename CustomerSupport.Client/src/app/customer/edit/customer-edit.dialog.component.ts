import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Customer } from 'src/app/models/customer.model';
import { Inquiry } from 'src/app/models/inquiry.model';
import { AlertService, MessageSeverity } from 'src/app/services/alert.service';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.dialog.component.html',
  styleUrls: ['./customer-edit.dialog.component.scss']
})
export class CustomerEditDialogComponent implements OnInit {

  inquiries: Inquiry[] = [];  
  matcher = new ErrorStateMatcher();

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  // phoneFormControl = new FormControl('', [Validators.required]);
  // issueDescriptionFormControl = new FormControl('', [Validators.required]);
  // agreeTermsFormControl = new FormControl('', [Validators.required]);

  constructor(public dialogRef: MatDialogRef<CustomerEditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Customer,
    public dataService: CustomerService,
    public alertService: AlertService) { }

  ngOnInit(): void {
    this.loadInquiries();
  }

  loadInquiries(): void{
    this.dataService.getInquiries().subscribe(result =>{
      this.inquiries = result as Inquiry[];
    })
  }
  save(): void {
    if(this.data.id){
      this.dataService.update(this.data).subscribe(data =>{
        this.alertService.showStickyMessage("Successfully edited", MessageSeverity.success);
        this.dialogRef.close();
      }, error =>{
        this.alertService.showStickyMessage("", MessageSeverity.error, error);
      });
    }else{
      this.dataService.add(this.data).subscribe(data =>{
        this.alertService.showStickyMessage("Successfully created", MessageSeverity.success);
        this.dialogRef.close();
      }, error =>{
        this.alertService.showStickyMessage("", MessageSeverity.error, error);
      });
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  submit() {
  }

}
