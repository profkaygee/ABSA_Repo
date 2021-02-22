import {SelectionModel} from "@angular/cdk/collections";
import {Component} from "@angular/core";
import {MatDialog} from "@angular/material/dialog";
import {AddPhonebookComponent} from "../add-phonebook/add-phonebook.component";
import {Entry} from "../classes/entry";
import {MatTableDataSource} from "@angular/material/table";
import {DataService} from "../services/data.service";
import {Phonebook} from "../classes/phonebook";
import {ToastrService} from "ngx-toastr";
import {AddPhonebookEntryComponent} from "../add-phonebook-entry/add-phonebook-entry.component";

let ELEMENT_DATA: Entry[] = [
  {
    PhoneEntryId: 1,
    Name: "Hydrogen",
    PhoneNumber: "065 868 8810",
    PhonebookId: 1
  }
];

@Component({selector: "app-home", templateUrl: "./home.component.html", styleUrls: ["./home.component.scss"]})
export class HomeComponent {
  phonebookName: string;
  hasPhonebook: boolean;
  displayedColumns: string[] = ["position", "name", "phoneNumber"];
  dataSource = new MatTableDataSource<Entry>(ELEMENT_DATA);
  selection = new SelectionModel<Entry>(true, []);
  searchPhrase: string;
  Name: string;
  PhoneNumber: string;
  phonebookId: number;

  constructor(public dialog : MatDialog, private dataApi : DataService, private toastr : ToastrService) {
    // Select the first one when we start.
    this.SelectPhonebookEntries(this.phonebookId);
    this.hasPhonebook = true;
  }

  showAddPhonebook() {
    const dialogRef = this.dialog.open(AddPhonebookComponent, {
      width: "550px",
      data: {
        phonebookName: this.phonebookName
      }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result !== null && result !== undefined) {
        this.phonebookName = result;
        this.hasPhonebook = true;

        const phoneBook = new Phonebook();
        phoneBook.BookName = this.phonebookName;
        this.dataApi.AddPhonebook(phoneBook).subscribe((data) => {
          if (data.successResponse) {
            this.toastr.success(data.errorMessage);
            this.phonebookId = data.newId;
            this.SelectPhonebookEntries(data.newId);
          } else {
            this.toastr.error(data.errorMessage);
          }
        });
      }
    });
  }

  showAddPhonebookEntry() {
    const dialogRef = this.dialog.open(AddPhonebookEntryComponent, {
      width: "650px",
      data: {
        Name: this.Name,
        PhoneNumber: this.PhoneNumber
      }
    });

    dialogRef.afterClosed().subscribe((result : any) => {
      if (result !== null && result !== undefined) {
        debugger;
        this.Name = result.Name.toString();
        this.PhoneNumber = result.PhoneNumber.toString();

        const phoneBookEntry = new Entry();
        phoneBookEntry.Name = this.Name;
        phoneBookEntry.PhoneNumber = this.PhoneNumber;
        phoneBookEntry.PhonebookId = this.phonebookId;

        this.dataApi.AddPhonebookEntry(phoneBookEntry).subscribe((data) => {
          debugger;
          if (data.successResponse) {
            this.toastr.success(data.errorMessage);
            this.SelectPhonebookEntries(data.newId);
          } else {
            this.toastr.error(data.errorMessage);
          }
        });
      }
    });
  }

  SelectPhonebookEntries(phonebookId) {
    this.dataApi.SelectPhonebookEntries(phonebookId).subscribe((data) => {
      debugger;

      this.dataSource = new MatTableDataSource<Entry>(data);
      this.hasPhonebook = true;
    });
  }

  search() {
    debugger
    this.dataApi.SearchPhrase(this.searchPhrase).subscribe((data) => {
      debugger
      
      this.dataSource = new MatTableDataSource<Entry>(data);
      this.hasPhonebook = true;
    });
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.data.forEach((row) => this.selection.select(row));
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row? : Entry): string {
    if (!row) {
      return `${this.isAllSelected()
        ? "select"
        : "deselect"} all`;
    }
    return `${
    this.selection.isSelected(row)
      ? "deselect"
      : "select"} row ${row.PhoneEntryId + 1}`;
  }
}
