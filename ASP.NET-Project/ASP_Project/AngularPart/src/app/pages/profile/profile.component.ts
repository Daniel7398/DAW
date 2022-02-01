import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  public userId: number = 0;

  constructor(private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params: any) => {
      console.log(params);
      this.userId = parseInt(params['id']);
      console.log(this.userId);
    });

    this.activatedRoute.queryParams.subscribe((qPrams: any) => {
      console.log(qPrams);
    });
  }
}
