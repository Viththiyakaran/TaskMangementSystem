import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateTaskManagementComponent } from './create-task-management.component';

describe('CreateTaskManagementComponent', () => {
  let component: CreateTaskManagementComponent;
  let fixture: ComponentFixture<CreateTaskManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateTaskManagementComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateTaskManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
