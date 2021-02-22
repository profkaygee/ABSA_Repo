import {Component, Inject, OnInit} from "@angular/core";
import {MatDialogRef, MAT_DIALOG_DATA} from "@angular/material/dialog";
import {Entry} from "../classes/entry";

@Component({selector: "app-add-phonebook-entry", templateUrl: "./add-phonebook-entry.component.html", styleUrls: ["./add-phonebook-entry.component.css"]})
export class AddPhonebookEntryComponent implements OnInit {
  constructor(public dialogRef : MatDialogRef<AddPhonebookEntryComponent>, @Inject(MAT_DIALOG_DATA)public data : Entry) {}

  ngOnInit(): void {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
