import { environment } from "../../../environments/environment";
import { ErrorHandler, Injectable, Injector } from "@angular/core";
import { Router } from "@angular/router";
import { ModalService } from "../services/modal.service";

@Injectable()
export class CustomErrorHandler implements ErrorHandler
{
	constructor(private readonly injector: Injector) { }

	modalService: ModalService;
	router: Router;

	handleError(error)
	{
		this.modalService = this.injector.get(ModalService);
		this.router = this.injector.get(Router);

		if (error.status)
		{
			switch (error.status)
			{
				case 400: { this.modalService.alert(error.error); }
				case 401: { this.router.navigate(["/login"]); }
			}
		}
	}
}
