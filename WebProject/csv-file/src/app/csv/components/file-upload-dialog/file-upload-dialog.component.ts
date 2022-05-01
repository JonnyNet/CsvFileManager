import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { CreateCsvFile } from '../../models/create-csv-file';

@Component({
  selector: 'app-file-upload-dialog',
  templateUrl: './file-upload-dialog.component.html',
  styleUrls: ['./file-upload-dialog.component.scss']
})
export class FileUploadDialogComponent {

  file: any;
  baseDropValid: any;
  accept = ".csv"
  fileDropDisabled = false;
  dataFile!: CreateCsvFile;

  constructor(public readonly dialogRef: MatDialogRef<FileUploadDialogComponent>) { }

  LoadFile(data: any): void {
    const file = data[data.length - 1];
    this.dataFile = { name: file.name, data: '' };
    this.fileDropDisabled = true;
    const fileReader = new FileReader();
    const self = this;
    fileReader.onloadend = (e: any) => {
      self.dataFile.data = e.target.result;
    };
    fileReader.readAsDataURL(file);
  }

  deleteFile(): void {
    this.file = undefined;
    this.dataFile = undefined as any;
    this.fileDropDisabled = false;
  }

  onSubmit(): void {
    this.dialogRef.close(this.dataFile);
  }
}
