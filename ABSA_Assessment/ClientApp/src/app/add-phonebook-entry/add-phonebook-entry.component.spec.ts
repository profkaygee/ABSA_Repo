import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPhonebookEntryComponent } from './add-phonebook-entry.component';

describe('AddPhonebookEntryComponent', () => {
  let component: AddPhonebookEntryComponent;
  let fixture: ComponentFixture<AddPhonebookEntryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddPhonebookEntryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPhonebookEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
