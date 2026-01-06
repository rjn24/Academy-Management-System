import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-students',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './students.component.html'
})
export class StudentsComponent implements OnInit {

  students: any[] = [];
  model: any = {};
  editing = false;
  showTable = false;
  constructor(private studentService: StudentService) {}

  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents() {
    this.studentService.getStudents().subscribe(data => {
      this.students = data;
    });
  }

  saveStudent() {
    if (this.editing) {
      this.studentService.updateStudent(this.model.studentID, this.model)
        .subscribe(() => {
          this.reset();
          this.loadStudents();
        });
    } else {
      this.studentService.addStudent(this.model)
        .subscribe(() => {
          this.reset();
          this.loadStudents();
        });
    }
  }

  editStudent(student: any) {
    this.model = { ...student };
    this.editing = true;
  }

  deleteStudent(id: number) {
    this.studentService.deleteStudent(id)
      .subscribe(() => this.loadStudents());
  }

  reset() {
    this.model = {};
    this.editing = false;
  }
}
