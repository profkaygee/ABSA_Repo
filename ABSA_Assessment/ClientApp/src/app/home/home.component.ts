import { SelectionModel } from '@angular/cdk/collections';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddPhonebookComponent } from '../add-phonebook/add-phonebook.component';
import { Entry } from '../classes/entry';
import { MatTableDataSource } from '@angular/material/table';

const ELEMENT_DATA: Entry[] = [
  { position: 1, name: 'Hydrogen', phoneNumber: '065 868 8810' }
];

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  phonebookName: string;
  hasPhonebook: boolean;
  displayedColumns: string[] = ['position', 'name', 'phoneNumber'];
  dataSource = new MatTableDataSource<Entry>(ELEMENT_DATA);
  selection = new SelectionModel<Entry>(true, []);
  searchPhrase: string;

  constructor(public dialog: MatDialog) { }

  showAddPhonebook() {
    const dialogRef = this.dialog.open(AddPhonebookComponent, {
      width: '550px',
      data: { phonebookName: this.phonebookName }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.phonebookName = result;
      this.hasPhonebook = true;
      window.alert(result);
    });
  }

  search(){
    
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: Entry): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.position + 1}`;
  }
}
