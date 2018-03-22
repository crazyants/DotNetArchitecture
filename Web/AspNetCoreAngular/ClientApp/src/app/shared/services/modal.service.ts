import { Injectable } from "@angular/core";

declare var UIkit: any;

@Injectable()
export class ModalService
{
	alert(message): void
	{
		UIkit.modal.alert(message);
	}
}