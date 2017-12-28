import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatGridListModule, MatCardModule } from '@angular/material';

@NgModule({
    imports: [MatButtonModule, MatGridListModule, MatCardModule],
    exports: [MatButtonModule, MatGridListModule, MatCardModule],
})
export class MaterialModule { }