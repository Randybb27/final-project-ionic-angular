import { Component, OnInit } from '@angular/core';
import { Dialog } from '@capacitor/dialog';
import { Tasks } from '../models/tasks';
import { DialogService } from '../services/dialog.service';
import { TaskServiceService } from '../task-service.service';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.page.html',
  styleUrls: ['./task-list.page.scss'],
})
export class TaskListPage implements OnInit {
  toggle(arg0: any) {
    throw new Error('Method not implemented.');
  }
  TaskId: any;
  // Task: any;


  Incomplete: Tasks[];
  Complete: Tasks[];

  dialogService: DialogService;
  service: TaskServiceService;
  tasks: Tasks;

  constructor(dialogService: DialogService, service: TaskServiceService) {
    this.dialogService = dialogService
    this.service = service
  }

  ngOnInit() {

    this.service.getAllTasks().subscribe(s => {
      this.Complete = s.filter(f => f.Completed);
    });

    this.service.getAllTasks().subscribe(s => {
      this.Incomplete = s.filter(f => !f.Completed);
    });

  }

  delete(id: any) {
    this.service.deleteTaskByID(id).subscribe(response => {
      console.log(response);
      this.ngOnInit();
    })
  }

  setToComplete(id: number) {
    // this.service.setToComplete(id).subscribe(s =>)
    this.service.setTaskComplete(id).subscribe(r => {
      this.service.getAllTasks().subscribe(s => {
        this.Incomplete = s.filter(f => !f.Completed);
      });
      this.service.getAllTasks().subscribe(s => {
        this.Complete = s.filter(f => f.Completed);
      });
    });
  }

  setToIncomplete(id: number) {
    // this.service.setToComplete(id).subscribe(s =>)
    this.service.setTaskIncomplete(id).subscribe(r => {
      this.service.getAllTasks().subscribe(s => {
        this.Complete = s.filter(f => !f.Incompleted);
      });

      this.service.getAllTasks().subscribe(s => {
        this.Incomplete = s.filter(f => f.Incompleted);
      });
    });
  }


  prompt() {
    this.dialogService.showPrompt("Task Title", "taskId").subscribe(response => {
      console.log('Task Title: ' + response);
      let newTask = new Tasks();
      newTask.title = response;
      this.service.createNewTask(newTask).subscribe(s => { console.log(s) })
    });
  }
}
