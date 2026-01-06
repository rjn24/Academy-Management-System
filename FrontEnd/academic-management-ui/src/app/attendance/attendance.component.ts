import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AttendanceService } from '../services/attendance.service';

@Component({
  selector: 'app-attendance',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './attendance.component.html'
})
export class AttendanceComponent implements OnInit {

  // ✅ List for table
  attendanceList: any[] = [];

  // ✅ Form model
  model: any = {};

  // ✅ UI state
  showTable = false;

  constructor(private attendanceService: AttendanceService) {}

  ngOnInit(): void {
    this.loadAttendance();
  }

  // 🔹 Load attendance records
  loadAttendance() {
    this.attendanceService.getAttendance().subscribe({
      next: data => this.attendanceList = data,
      error: err => console.error('Attendance load error', err)
    });
  }

  // 🔹 Add attendance record
  saveAttendance() {
    this.attendanceService.addAttendance(this.model).subscribe({
      next: () => {
        this.model = {};
        this.loadAttendance();
        this.showTable = true;
      },
      error: err => console.error('Save attendance error', err)
    });
  }

  // 🔹 Delete attendance record
  deleteAttendance(id: number) {
    this.attendanceService.deleteAttendance(id).subscribe({
      next: () => this.loadAttendance(),
      error: err => console.error('Delete attendance error', err)
    });
  }
}
