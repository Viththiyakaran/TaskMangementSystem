import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTaskManagementComponent } from './edit-task-management.component';

describe('EditTaskManagementComponent', () => {
  let component: EditTaskManagementComponent;
  let fixture: ComponentFixture<EditTaskManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditTaskManagementComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditTaskManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
