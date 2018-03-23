import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgModule } from "@angular/core";

import { ValidationModule } from "./validation/validation.module";

@NgModule({
	exports: [
		ValidationModule
	],
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,
		ValidationModule
	]
})
export class DirectivesModule { }
