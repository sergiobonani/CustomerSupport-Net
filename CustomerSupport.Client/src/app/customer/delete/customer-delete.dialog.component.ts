import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AlertService, MessageSeverity } from 'src/app/services/alert.service';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-delete',
  templateUrl: './customer-delete.dialog.component.html',
  styleUrls: ['./customer-delete.dialog.component.scss']
})
export class CustomerDeleteDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<CustomerDeleteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, 
    public dataService: CustomerService,
    public alertService: AlertService) { }

  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  confirmDelete(): void {
    this.dataService.delete(this.data.id).subscribe(data =>{
      this.alertService.showStickyMessage("Successfully deleted", MessageSeverity.success);
      this.dialogRef.close();
    }, error =>{
      this.alertService.showStickyMessage("", MessageSeverity.error, error);
    });;
  }

}
