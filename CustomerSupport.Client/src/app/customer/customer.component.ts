import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';
import { CustomerDeleteDialogComponent } from './delete/customer-delete.dialog.component';
import { CustomerEditDialogComponent } from './edit/customer-edit.dialog.component';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  displayedColumns = ['email', 'issue_description', 'agree_terms', 'actions'];
  public dataSource = new MatTableDataSource<Customer>();
  // @ViewChild(MatSort, {static: true}) sort: MatSort;
  // @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  @ViewChild(MatSort, { static: false }) set sort(val: MatSort) {
    if (val) {
      this.dataSource.sort = val;
    }
  }

  @ViewChild(MatPaginator, { static: false }) set paginator(val: MatPaginator) {
    if (val) {
      this.dataSource.paginator = val;
    }
  }
  
  constructor(public dataService: CustomerService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.loadData();
   }
 
   loadData(){
     this.dataService.getAll().subscribe(result =>{
       this.dataSource.data = result as Customer[];
     })
   }

   addNew() {
    const dialogRef = this.dialog.open(CustomerEditDialogComponent, {
      data:  new Customer()
    });

    dialogRef.afterClosed().subscribe(result => {
      this.loadData();
    });
  }

  startEdit(id: string) {
    this.dataService.getById(id).subscribe(result => {
      const dialogRef = this.dialog.open(CustomerEditDialogComponent, {
        data: result
      });

      dialogRef.afterClosed().subscribe(result => {
        this.loadData();
      });
  });
}

   public doFilter = (event: any) => {
    this.dataSource.filter = event.target.value.trim().toLocaleLowerCase();
  }

  deleteItem(row: Customer){
    if(row){
      const dialogRef = this.dialog.open(CustomerDeleteDialogComponent, {
        data: row
      });

      dialogRef.afterClosed().subscribe(result => {
          this.loadData();
      });
    }
  }

  hasData(){
    return this.dataSource && this.dataSource.data && this.dataSource.data.length > 0; 
  }
}
