import { Component, OnInit } from '@angular/core';
import { PrivateService } from 'src/app/services/private.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  public users: any[] = [
    {
      firstName: 'Ana',
      lastName: 'Popescu',
    },
    {
      firstName: 'Ionel',
      lastName: 'Dinescu',
    },
  ];
  public text: string = 'CEVA';
  public searchText: string = '';
  constructor(private privateService: PrivateService) {}

  ngOnInit(): void {
    //this.getAllUsers();
  }

  getAllUsers() {
    this.privateService.getUsers().subscribe((response: any) => {
      this.users = response.allUsers;
    });
  }

  deleteUser(firstName: string) {
    this.users = this.users.filter((user) => {
      return user.firstName !== firstName;
    });
  }
}
