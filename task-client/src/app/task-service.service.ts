import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tasks } from './models/tasks';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class TaskServiceService {

  dataSource: string ="http://localhost:5056/task"


  constructor(private http: HttpClient) { }

  getAllTasks(): Observable<Tasks[]> {
    return this.http.get<Tasks[]>(this.dataSource);
}

getTaskByID(id: number): Observable<Tasks> {
  return this.http.get<Tasks>(this.dataSource + "/" + id);
}

createNewTask(newTitle: Tasks): Observable<Tasks>{
  return this.http.post<Tasks>(this.dataSource, newTitle);
}


deleteTaskByID(id: number): Observable<Tasks> {
  return this.http.delete<Tasks>(this.dataSource + "/" + id);

}

setTaskComplete(id: number): Observable<Tasks> {
  return this.http.post<Tasks>(this.dataSource + "/setComplete/" + id, id)

}

setTaskIncomplete(id: number): Observable<Tasks> {
  return this.http.post<Tasks>(this.dataSource + "/setIncomplete/" + id, id)

}

}
