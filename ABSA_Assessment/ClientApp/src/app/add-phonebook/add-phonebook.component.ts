import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Phonebook } from '../classes/phonebook';

@Component({
  selector: 'app-add-phonebook',
  templateUrl: './add-phonebook.component.html',
  styleUrls: ['./add-phonebook.component.css']
})
export class AddPhonebookComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<AddPhonebookComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Phonebook) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
  }

}
