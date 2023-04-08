import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit{
  @Input() label: string | undefined;
  @Input() type: string | undefined;
  @Input() class: string | undefined;
  
  constructor(){}

  ngOnInit(): void { }

}
