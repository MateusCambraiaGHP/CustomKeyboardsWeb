import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent  implements OnInit{
  @Input() title: string = '';
  @Input() subtitle: string = '';
  @Input() class: string = '';
  
  constructor(){}
  
  ngOnInit(): void { }
}
