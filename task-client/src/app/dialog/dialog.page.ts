import { Component, OnInit } from '@angular/core';
import { DialogService } from '../services/dialog.service';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.page.html',
  styleUrls: ['./dialog.page.scss'],
})
export class DialogPage implements OnInit {

  constructor(private dialogService: DialogService) { }

  ngOnInit() {
  }
  prompt() {
    this.dialogService.showPrompt("Task Title", "taskId").subscribe(response => {
        console.log('Task Title: ' + response);
    });
  }
}
