// import { Component, Input } from '@angular/core';

// @Component({
//   selector: 'app-modal',
//   templateUrl: './modal.component.html',
//   styleUrls: ['./modal.component.scss']
// })
// export class ModalComponent {
// 	@Input()
//     title!: string;
// 	@Input() size: string = 'md';
// 	@Input() full: boolean = false;
// 	@Input() showFooter: boolean = false;
// 	@Input() notClosed: boolean = false;
// 	@Input() disabled: boolean = false;
// 	@Input()
//     callbackClose!: Function;

// 	constructor(private modalService: NgbModal) { }

// 	openModal(content) {
// 		if (this.disabled) return;

// 		this.modalService.open(
// 			content,
// 			{
// 				centered: true,
// 				size: this.size,
// 				windowClass: this.addClass(),
// 				backdrop: (this.notClosed || this.callbackClose) ? 'static' : true,
// 				keyboard: (this.notClosed || this.callbackClose) ? false : true,
// 			}
// 		);
// 	}

// 	closeModal(modal: any) {
// 		if (this.callbackClose) this.callbackClose();
// 		modal.close('Close click')
// 	}

// 	addClass() {
// 		let _class = '';
// 		if (this.full) _class += 'modal-full ';
// 		return _class
// 	}
// }
