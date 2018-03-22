import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgModule } from "@angular/core";

import { AppInputComponent } from "./input/input.component";
import { AppSelectComponent } from "./select/select.component";

@NgModule({
	declarations: [
		AppInputComponent,
		AppSelectComponent
	],
	exports: [
		AppInputComponent,
		AppSelectComponent
	],
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule
	]
})
export class ComponentsModule { }