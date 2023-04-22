import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-overlay-loading',
  templateUrl: './overlay-loading.component.html',
  styleUrls: ['./overlay-loading.component.scss']
})
export class OverlayLoadingComponent {
    @Input() isLoading: Boolean | undefined;
    @Input() execute: Function | undefined;
    loading: boolean = true;

    constructor() { }

    ngOnInit(): void {
      this.start();
    }

    async start() {
      if (this.execute)
        await this.execute();
      this.loading = false
    }
}
